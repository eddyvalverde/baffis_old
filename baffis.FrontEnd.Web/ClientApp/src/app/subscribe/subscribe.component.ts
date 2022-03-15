import { Component, OnInit } from '@angular/core';
import { Subscription } from '../subscription'
import { Order } from '../Order'
import { SubscriptionService } from '../subscription.service'
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})
export class SubscribeComponent implements OnInit {

  subscription: Subscription;
  public isSubscribed: Observable<boolean>;
 
  userErrMess: string;

  constructor(private subscriptionService: SubscriptionService, private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.getSubscription();
    this.isSubscribeT();
  }
  getSubscription(): void {
    //this.subscriptionService.getSubscription().subscribe(subscription => this.subscription = subscription);
    
    this.subscriptionService.getSubscription().subscribe(subscription_in => { this.subscription = subscription_in; console.log(this.subscription) }, errmess => this.userErrMess = <any>errmess);
  }
  subscribe(): void {
    if (this.authorizeService.isAuthenticated()) {

      this.authorizeService.getUser()
        .subscribe(data => {
          this.subscriptionService.subscribe({ subscription: this.subscription, subscriber: data.sub } as Order);
          // console.log(data); //You will get all your user related information in this field
        }).unsubscribe();

      //window.location.reload();

    }
    else {
      this.subscriptionService.pay();
    }
    
  }

  unsubscribe(): void {
    if (this.authorizeService.isAuthenticated()) {

      this.authorizeService.getUser()
        .subscribe(data => {
          this.subscriptionService.unsubscribe(data.sub);
          // console.log(data); //You will get all your user related information in this field
        });

      //window.location.reload();

    }

  }

  isSubscribeT(): void {
      this.authorizeService.getUser()
      .subscribe(data => {
        this.isSubscribed = this.subscriptionService.isSubscribed(data.sub);
        // console.log(data); //You will get all your user related information in this field
      }).unsubscribe();
  }
  

}
