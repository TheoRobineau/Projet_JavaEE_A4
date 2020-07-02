/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.process.processservice;

import com.process.netplateforme.FrontService;
import com.process.netplateforme.IFrontService;
import java.nio.charset.StandardCharsets;
import java.text.Normalizer;
import java.util.List;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.EJB;
import javax.ejb.MessageDriven;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.TextMessage;
import java.text.Normalizer;
import java.util.regex.Pattern;
import javax.jms.BytesMessage;

/**
 *
 * @author patri
 */
@MessageDriven(mappedName = "jms/NewMessageQueue", activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class MessageBean implements MessageListener {

    @EJB
    WordDAO wordDAO;

    public MessageBean() {
    }

    @Override
    public void onMessage(Message message) {
        try {
            //Récupération du message
            //TextMessage textMessage = (TextMessage) message;
            //String file = textMessage.getText();
            //String key = textMessage.getStringProperty("key");
            //String fileName = textMessage.getStringProperty("fileName");

            BytesMessage bytesMessage = (BytesMessage)message;
            byte[] byteData = null;
            byteData = new byte[(int) bytesMessage.getBodyLength()];
            bytesMessage.readBytes(byteData);

            String file = new String(byteData, StandardCharsets.UTF_8);

            String key = bytesMessage.getStringProperty("key");
            String fileName = bytesMessage.getStringProperty("fileName");

            System.out.println("fichier = " + file + "\n" + "clé = "+ key + "\n" + "nom du fichier = " + fileName);

            //Récupération des mots du dictionnaire
            List<String> mots =  wordDAO.findMots();

            boolean french = wordDAO.checkRate(wordDAO.getOccurrence(file, mots));

            FrontService proxy = new FrontService();
            IFrontService port = proxy.getBasicHttpBindingIFrontService();


            if(french == true ){
                //System.out.println("Le fichier" + fileName + "n'est pas français avec la clé: " + key);

                String secretInfo = wordDAO.secretInfo(file.toLowerCase());
                System.out.println("Le fichier" + fileName + "est français avec la clé: " + key);

                String response = port.getResult(fileName, secretInfo, key);

                if(secretInfo != ""){
                 System.out.println("L'information secrète est:" + secretInfo + "et se trouve dans le fichier" + fileName + "en utilisant la clé" + key);
                 response = port.getResult(fileName, secretInfo, key);
                 System.out.println(response);
                }
                else{
                    System.out.println("Il n'existe pas d'information dans le fichier: " + fileName);
                }
            }
            else{
                System.out.println("Le fichier" + fileName + "n'est pas français avec la clé: " + key);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
