package com.receptionmessage;

import javax.jms.JMSException;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import java.io.UnsupportedEncodingException;


@WebService(name = "ReceptionEndPoint")
public interface ReceptionServiceBeanEndPointInterface {
    @WebMethod(operationName = "receptionOperation")
    void receptMessage(@WebParam(name = "file") byte[] file, @WebParam(name = "key") byte[] key, @WebParam(name = "fileName") byte[] fileName) throws JMSException, UnsupportedEncodingException;
}
