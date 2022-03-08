import { Injectable } from '@angular/core';
import { Subscription } from './subscription';
import { Order } from './order';
import { SUBSCRIPTIONS } from './mock-subscription';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  private subscriptionUrl = 'https://localhost:44333/api/v1.0/Subscription/Get/1';
  private subscribeUrl = 'https://localhost:44333/api/v1.0/Subscription/Post';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  getSubscription(): Observable<Subscription> {
    const subscription = this.http.get<Subscription>(this.subscriptionUrl);
    return subscription;
  }
  subscribe(order: Order): Observable<Order> {
    return this.http.post<Order>(this.subscribeUrl, order, this.httpOptions);/*.pipe(
      tap((newOder: Order) => this.log(`added hero w/ id=${newHero.id}`)),
      catchError(this.handleError<Hero>('addHero'))
    );*/
  }
}
