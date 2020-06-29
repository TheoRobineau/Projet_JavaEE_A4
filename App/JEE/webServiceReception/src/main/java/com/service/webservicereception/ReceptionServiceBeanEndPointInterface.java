/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.service.webservicereception;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;

/**
 *
 * @author patri
 */
@WebService(name = "ReceptionEndpoint")
public interface ReceptionServiceBeanEndPointInterface {
    @WebMethod(operationName = "ReceptionOperation")
    @WebResult(name = "receive")
    String receptMessage(@WebParam(name="file") String file, @WebParam(name="key")  String key, @WebParam(name="fileName") String fileName);
    @WebMethod(operationName = "ReceptionTest")
    @WebResult(name = "receiveTest")
    String testMessage(@WebParam(name="test") String test);
}
