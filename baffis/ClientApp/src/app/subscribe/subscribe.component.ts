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
 
  userErrMess: string;

  constructor(private subscriptionService: SubscriptionService) { }

  ngOnInit() {
    this.getSubscription();
  }
  getSubscription(): void {
    //this.subscriptionService.getSubscription().subscribe(subscription => this.subscription = subscription);
    this.subscriptionService.getSubscription().subscribe(subscription_in => { this.subscription = subscription_in; console.log(this.subscription) }, errmess => this.userErrMess = <any>errmess);
    
  }

}
