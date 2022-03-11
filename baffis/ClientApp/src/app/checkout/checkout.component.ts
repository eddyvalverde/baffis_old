import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { StripeService } from 'ngx-stripe';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded', 'Response-Type' : 'text' })

  };

  constructor(
    private http: HttpClient,
    private stripeService: StripeService  
  ) { }

  ngOnInit() {
  }

  checkout() {
    const formData = new FormData();
    formData.append('lookup_key', 'examplelookupkey');
    // Check the server.js tab to see an example implementation
    this.http.post<any>('https://localhost:44387/create-checkout-session', formData, this.httpOptions)
      .pipe(
        switchMap(session => {
          return this.stripeService.redirectToCheckout({ sessionId: session.id })
        })
      )
      .subscribe(result => {
        // If `redirectToCheckout` fails due to a browser or network
        // error, you should display the localized error message to your
        // customer using `error.message`.
        if (result.error) {
          alert(result.error.message);
          //window.location.href = result.error.message.get('url');
        }
      });
  }

}
