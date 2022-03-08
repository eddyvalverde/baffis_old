import { Injectable } from '@angular/core';
import { Subscription } from './subscription';
import { SUBSCRIPTIONS } from './mock-subscription';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {


  constructor() { }

  getSubscription(): Observable<Subscription> {
    const subscription = of(SUBSCRIPTIONS[0]);
    return subscription;
  }
}
