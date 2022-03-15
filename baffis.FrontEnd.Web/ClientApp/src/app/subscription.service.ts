import { Injectable } from '@angular/core';
import { Subscription } from './subscription';
import { Order } from './Order';
import { SUBSCRIPTIONS } from './mock-subscription';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { error } from '@angular/compiler/src/util';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  private subscriptionUrl = 'https://localhost:44333/api/v1.0/Subscription/Get/1';
  private subscribeUrl = 'https://localhost:44333/api/v1.0/Order/Post';
  private unsubscribeUrl ='https://localhost:44333/api/v1.0/Order/Delete/'
  private isSubscribedUrl = 'https://localhost:44333/api/v1.0/Order/isSubscribed/';
  private payUrl = 'https://localhost:44387/create-checkout-session';
  private errorMessage;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  getSubscription(): Observable<Subscription> {
    const subscription = this.http.get<Subscription>(this.subscriptionUrl);
    return subscription;
  }
  subscribe(order: Order): Observable<Order> {
    
    const val = this.http.post<Order>(this.subscribeUrl, order, this.httpOptions).pipe(
      tap((neworder: Order) => console.log(`added order w/ subscriber=${order.subscriber}`))
    );
    val.subscribe();
    return val;
  }

  isSubscribed(subscriber: string): Observable<boolean> {

    const order = this.http.get<boolean>(this.isSubscribedUrl + subscriber);
    return order;
  }

  unsubscribe(subscriber: string): void {
    const urltemp = this.unsubscribeUrl + subscriber;
    this.http.delete(urltemp, this.httpOptions).subscribe(() => console.log("order deleted"));
    this.errorMessage = error;
    
  }

  pay(): void {
    var formData: any = new FormData();
    formData.append('lookup_key', 'examplelookupkey');
    this.http.post<any>(this.subscribeUrl, formData, this.httpOptions).subscribe(res => {
      console.log(res)
    }, err => {
      console.log(err.url) // here is the redirect url
      window.location.href = err.url
    })
    
  }
}
