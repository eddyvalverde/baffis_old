import { Injectable } from '@angular/core';
import { Subscription } from './subscription';
import { SUBSCRIPTIONS } from './mock-subscription';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  constructor() { }

  getSubscription(): Subscription {
    return SUBSCRIPTIONS[0];
  }
}
