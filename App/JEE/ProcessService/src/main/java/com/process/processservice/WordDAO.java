/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.process.processservice;

import java.util.Arrays;
import javax.persistence.*;
import javax.ejb.Stateless;
import java.util.List;
import java.util.Scanner;
/**
 *
 * @author patri
 */
@Stateless
public class WordDAO {
    private static final EntityManagerFactory emf = Persistence.createEntityManagerFactory("NewPersistenceUnit");

    // Méthode pour retourner l'ensemble des mots de la base de données MOT
    public List<String> findMots() {
        String q = "SELECT m.mot FROM Mot m";
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        TypedQuery<String> query = em.createQuery(q, String.class);
        List<String> mots = query.getResultList();
        em.getTransaction().commit();
        em.close();

        return mots;
    }
    
    // Méthode pour compter le nombre d'occurrence
    public double[] getOccurrence(String msg, List<String> dict) {
        String wordMsg, wordDict;
        int counter;
        double countWord = 0, numCommon = 0;
        int dictSize = dict.size();
        double results[] = new double[2];
        
        long start = System.currentTimeMillis();
        
        // Parcours du message
        try {
            Scanner scanMsg = new Scanner(msg);
            while (scanMsg.hasNext()) {
                wordMsg = scanMsg.next().replace(" ","").replace(",","").replace(".","").replace("'","\n").replace("!","")
                            .replace("?", "").replace(":", "").replace("-", " ");
                                                                
                counter = 0;
                //Comparaison de chaque mot du message ayant au moins 3 lettres au dictionnaire
                while(counter < dictSize && wordMsg.length() > 2){
                    wordDict = dict.get(counter);
                    if(wordDict.equalsIgnoreCase(wordMsg)) {
                        numCommon++;
                        counter = dictSize;
                    }
                    counter++;
                }
                
                // Compteur du nombre de mot du message
                if(wordMsg.length() > 2){
                    countWord++;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        
        System.out.println((System.currentTimeMillis()-start)/1000F + " secondes");
        
        results[0] = numCommon;
        results[1] = countWord;
        
        return results;
    }
    
    // Méthode pour vérifier le taux de confiance
    public boolean checkRate(double[] occResults){
        boolean result;
        double rate;
        double numCommon = occResults[0];
        double countWord = occResults[1];
        
        //Taux de confiance = 1/2 des mots totals du message
        rate = numCommon/countWord*100;
        
        if(rate > 50){
            result = true;
            System.out.println("Le texte est français");
        } else {
            result = false;
            System.out.println("Le texte n'est pas français");
        }
        
        return result;
    }
}
