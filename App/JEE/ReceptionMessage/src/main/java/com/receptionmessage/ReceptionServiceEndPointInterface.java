/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.receptionmessage;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 *
 * @author ALEX
 */
@WebService(name = "ReceptionEndpoint")
public interface ReceptionServiceEndPointInterface {
    @WebMethod(operationName = "receptionOperation")
    void createQueue(@WebParam(name="file")  byte[] file, @WebParam(name="key") byte[] key) ;
}
