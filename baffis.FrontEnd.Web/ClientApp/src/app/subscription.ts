import { Currency } from './currency';
export interface Subscription {
  IdSubscription: number;
  Title: string;
  Description: string;
  Cost: number;
  currency: Currency;
}
