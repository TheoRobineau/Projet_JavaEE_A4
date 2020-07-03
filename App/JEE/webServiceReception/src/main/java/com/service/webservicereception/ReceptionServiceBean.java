/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.service.webservicereception;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.jms.BytesMessage;
import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.MessageProducer;
import javax.jms.Queue;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.jws.WebService;

/**
 *
 * @author patri
 */
@WebService(
    endpointInterface = "com.service.webservicereception.ReceptionServiceBeanEndPointInterface",
    portName = "ReceptionPort", 
    serviceName = "ReceptionService"
)
@Stateless
public class ReceptionServiceBean implements ReceptionServiceBeanEndPointInterface {
    @Resource(mappedName = "jms/MessageQueueFactory")
    private ConnectionFactory connectionFactory;
    
    @Resource(mappedName = "jms/NewMessageQueue")
    private Queue queue;
    
    @Override
    //public String receptMessage(String file, String key, String fileName){
    public String receptMessage(byte[] file, String key, String fileName){
        try{
             System.out.println("test");
            Connection connection = connectionFactory.createConnection();
            Session session = connection.createSession();
            MessageProducer messageProducer = session.createProducer(queue);
            //TextMessage message = session.createTextMessage();
            
            BytesMessage message = session.createBytesMessage();
            message.writeBytes(file);
            message.setStringProperty("key", key);
            message.setStringProperty("fileName", fileName);
           
            messageProducer.send(message);
        } catch(Exception e) {
            e.printStackTrace();
        }
        return "message reçu";
    }
    
    @Override
    public String testMessage(String test) {
        try{
            Connection connection = connectionFactory.createConnection();
            Session session = connection.createSession();
            MessageProducer messageProducer = session.createProducer(queue);
            TextMessage message = session.createTextMessage();
            message.setText(test);
            
            System.out.println(message);
            messageProducer.send(message);
        } catch(Exception e) {
            e.printStackTrace();
        }
        return "Message Send";
    }
}
