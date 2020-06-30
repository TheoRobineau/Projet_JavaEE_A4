/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.process.processservice;

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

/**
 *
 * @author patri
 */
@MessageDriven(mappedName = "jms/MessageQueue", activationConfig = {
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
            TextMessage textMessage = (TextMessage) message;
            String file = textMessage.getText();
            String key = textMessage.getStringProperty("key");
            String fileName = textMessage.getStringProperty("fileName");
//            System.out.println("fichier = " + file + "\n" + "clé = "+ key + "\n" + "nom du fichier = " + fileName);
            
            //Récupération des mots du dictionnaire
            List<String> mots =  wordDAO.findMots();
            
            wordDAO.checkRate(wordDAO.getOccurrence(file, mots));
            
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
