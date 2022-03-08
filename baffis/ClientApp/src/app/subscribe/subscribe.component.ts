import { Component, OnInit } from '@angular/core';
import { Subscription } from '../subscription'
import { Order } from '../order'
import { SubscriptionService } from '../subscription.service'
import { AuthorizeService } from '../../api-authorization/authorize.service';

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})
export class SubscribeComponent implements OnInit {

  subscription: Subscription;
 
  userErrMess: string;

  constructor(private subscriptionService: SubscriptionService, private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.getSubscription();
  }
  getSubscription(): void {
    //this.subscriptionService.getSubscription().subscribe(subscription => this.subscription = subscription);
    this.subscriptionService.getSubscription().subscribe(subscription_in => { this.subscription = subscription_in; console.log(this.subscription) }, errmess => this.userErrMess = <any>errmess);
    
  }
  subscribe(): void {
    if (this.authorizeService.isAuthenticated()) {
      
      /*const val = { subscription: this.subscription, subscriber: 'abc' };
      const val2 = this.authorizeService.getUser().;
      this.subscriptionService.subscribe(val as Order);*/
      this.authorizeService.getUser()
        .subscribe(data => {
          this.subscriptionService.subscribe({ subscription: this.subscription, subscriber: data.sub } as Order);
         // console.log(data); //You will get all your user related information in this field
        });
    }
    
  }

}
