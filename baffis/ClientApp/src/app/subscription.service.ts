import { Injectable } from '@angular/core';
import { Subscription } from './subscription';
import { SUBSCRIPTIONS } from './mock-subscription';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  private subscriptionUrl = 'https://localhost:44333/api/v1.0/Subscription/Get/1';
  constructor(private http: HttpClient) { }

  getSubscription(): Observable<Subscription> {
    const subscription = this.http.get<Subscription>(this.subscriptionUrl);
    return subscription;
  }
}
