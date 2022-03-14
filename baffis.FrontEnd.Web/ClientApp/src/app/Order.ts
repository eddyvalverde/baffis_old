import { Subscription } from './subscription';
export interface Order {
  subscription: Subscription;
  subscriber: string;
}
