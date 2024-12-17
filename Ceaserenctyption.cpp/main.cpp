#include <iostream>

using namespace std;

//ceaser encryption using ASCII codes

int main()
{
   int choice ;

   cout<< " 1. encryption" << endl<< " 2. decryption "<< endl<< "enter choice from (1,2) : " ;
   cin >> choice;


   if (choice == 1 ){
       cout <<"the text can only be alphabets "<<endl <<" enter  the message : " ;
       string message ;
       cin>> message;
       int key ;
       cout <<"the key can only be integers  "<<endl <<" enter  the key from (1,25) : " ;
       cin>> key;
       string encmessage =  message ;

       for (int i = 0; i <message.size() ; i++) {

           if (message[i] == 32) continue;
           else if ( message[i] > 122){
               int temp = (message[i]+ key) -122 ;
               encmessage = temp + 96 ;
           }
           else if ( message[i] >90 && message[i]<= 96){
               int temp = (message[i]+ key) -90 ;
               encmessage = temp + 64 ;
           } else{
               encmessage [i] += key ;
           }
       }

       cout << " the encrypted message : " << encmessage<< endl ;


   } else if (choice == 2){
       cout <<"the text can only be alphabets "<<endl <<" enter  the encrypted message : " ;
       string encryptedmessage ;
       cin>> encryptedmessage;

       int key ;
       cout <<"the key can only be integers  "<<endl <<" enter  the key from (1,25) : " ;
       cin>> key;
       string demessage =  encryptedmessage ;

       for (int i=0 ; i< demessage.size(); i++ ){
           if (encryptedmessage[i] == 32) continue;


           else if ((demessage[i]-key)<97 && (demessage[i]-key)>90  ){
               int temp =(demessage[i]-key) +26 ;
                    demessage[i]+= temp ;
           }

           else if ((demessage[i]-key)<65){
               int temp =(demessage[i]-key) +26 ;
               demessage[i]+= temp ;
           }
           else {
               demessage[i]= encryptedmessage[i] - key ;

           }

       }
       cout << " the original message  : " << demessage ;


   } else{
       cout << " invalid choice " ;

   }
}
