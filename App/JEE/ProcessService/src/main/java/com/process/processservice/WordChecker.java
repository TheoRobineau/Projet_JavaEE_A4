/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.process.processservice;

/**
 *
 * @author patri
 */
public class WordChecker {
    public void checkWord() {

    }

    public static void main(String[] args) {
        // Dictionnaire de mots
        WordDAO wordDAO = new WordDAO();
        wordDAO.findMots();
        
//        //Message
//        MessageBean messageBean = new MessageBean();
//        String file = messageBean.getFile();
//        String key = messageBean.getKey();
//        String fileName = messageBean.getFileName();
//        System.out.println("fichier = " + file + "\n" + "clé = " + "\n" + "nom du fichier = " + fileName);
    }
}
