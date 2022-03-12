import { DOCUMENT } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AfterViewInit, Component, Inject, OnInit, Renderer2 } from '@angular/core';
import { StripeService } from 'ngx-stripe';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit, AfterViewInit  {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json', 'Response-Type': 'text', 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Headers': 'Origin,Content-Type,X-Auth-Token'})
    //Access-Control-Allow-Headers: Origin, Content-Type, X-Auth-Token
  };

  constructor(
    private http: HttpClient,
    private stripeService: StripeService,
    private renderer: Renderer2,
    @Inject(DOCUMENT) private _document
  ) { }
    ngAfterViewInit(): void {
      var s = this.renderer.createElement("script");
      //s.onload = this.loadNextScript.bind(this);
      s.type = "text/javascript";
      s.src = "https://js.stripe.com/v3/";

      this.renderer.appendChild(this._document.body, s);
    }

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
