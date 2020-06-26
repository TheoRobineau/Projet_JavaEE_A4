package com.receptionmessage;

import javax.annotation.Resource;
import javax.ejb.Stateless;
import javax.jms.BytesMessage;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Queue;
import javax.jws.WebService;
import javax.inject.Inject;
import java.io.UnsupportedEncodingException;


@Stateless
@WebService(
        endpointInterface = "com.receptionmessage.ReceptionServiceBeanEndPointInterface",
        portName = "ReceptionPort",
        serviceName = "ReceptionService"
)
public class ReceptionServiceBean implements ReceptionServiceBeanEndPointInterface{

    @Inject
    private JMSContext context;

    @Resource(lookup = "jms/messageQueue")
    private Queue messageQueue;

    public void receptMessage(byte[] file, byte[] key, byte[] fileName) throws JMSException, UnsupportedEncodingException {
        String keyString = new String(key, "UTF-8");
        String fileNameString = new String(fileName, "UTF-8");

        BytesMessage bytesMessage = context.createBytesMessage();
        bytesMessage.writeBytes(file);
        bytesMessage.setStringProperty("key", keyString);
        bytesMessage.setStringProperty("fileName", fileNameString);
        context.createProducer().send(messageQueue,bytesMessage);
        context.close();
    }
}
