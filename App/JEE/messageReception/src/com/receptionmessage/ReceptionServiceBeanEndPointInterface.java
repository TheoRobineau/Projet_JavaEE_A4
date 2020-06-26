package com.receptionmessage;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;


@WebService(name = "ReceptionEndPoint")
public interface ReceptionServiceBeanEndPointInterface{
    @WebMethod(operationName = "receptionOperation")
    void receptMessage(@WebParam(name="file") byte[] file, @WebParam(name="key") byte[] key);
}
