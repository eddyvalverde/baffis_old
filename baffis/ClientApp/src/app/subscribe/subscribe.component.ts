import { Component, OnInit } from '@angular/core';
import { SUBSCRIPTIONS } from '../mock-subscription';
import { Subscription } from '../subscription'

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})
export class SubscribeComponent implements OnInit {

  subscription: Subscription = SUBSCRIPTIONS[0];

  constructor() { }

  ngOnInit() {
  }

}
