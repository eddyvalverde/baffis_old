import { Component, OnInit } from '@angular/core';
import { Subscription } from '../subscription'
import { SubscriptionService } from '../subscription.service'

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})
export class SubscribeComponent implements OnInit {

  subscription: Subscription;

  constructor(private subscriptionService: SubscriptionService) { }

  ngOnInit() {
    this.getSubscription();
  }
  getSubscription(): void {
    this.subscription = this.subscriptionService.getSubscription();
  }

}
