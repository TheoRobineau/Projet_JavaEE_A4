/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.receptionmessage;

import javax.ejb.Stateless;
import javax.jws.WebService;

/**
 *
 * @author ALEX
 */
@Stateless
@WebService(
endpointInterface = "com.receptionMessage.ReceptionServiceEndPointInterface",
portName = "ReceptionPort", 
serviceName = "ReceptionService"
 )
public class ReceptionServiceBean implements ReceptionServiceEndPointInterface {
    public void createQueue(byte[] file, byte[] key){
    
    }
}
