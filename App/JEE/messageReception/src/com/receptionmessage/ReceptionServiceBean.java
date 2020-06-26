package com.receptionmessage;

import javax.ejb.Stateless;
import javax.jws.WebService;


@Stateless
@WebService(
        endpointInterface = "com.receptionmessage.ReceptionServiceBeanEndPointInterface",
        portName = "ReceptionPort",
        serviceName = "ReceptionService"
)
public class ReceptionServiceBean implements ReceptionServiceBeanEndPointInterface{

    public void receptMessage(byte[] file, byte[] key) {

        return;
    }
}
