import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StripeService {

  handler: any = null;
  constructor() { }

  loadStripe() {
    debugger;
   if(!window.document.getElementById('stripe-script')) {
     var s = window.document.createElement("script");
     s.id = "stripe-script";
     s.type = "text/javascript";
     s.src = "https://checkout.stripe.com/checkout.js";
     s.onload = () => {
       this.handler = (<any>window).StripeCheckout.configure({
         key: 'pk_test_aeUUjYYcx4XNfKVW60pmHTtI',
         locale: 'auto',
         token: function (token: any) {
           // You can access the token ID with `token.id`.
           // Get the token ID to your server-side code for use.
           console.log(token)
           alert('Payment Success!!');
         }
       });
     }
      
     window.document.body.appendChild(s);
   }
 }

  pay(amount) {    
    debugger;
    var handler = (<any>window).StripeCheckout.configure({
      key: 'pk_test_aeUUjYYcx4XNfKVW60pmHTtI',
      locale: 'auto',
      token: function (token: any) {
        // You can access the token ID with `token.id`.
        // Get the token ID to your server-side code for use.
        console.log(token)
        alert('Token Created!!');
      }
    });

    handler.open({
      name: 'Demo Site',
      description: '2 widgets',
      amount: amount * 100
    });
 
  }
}
