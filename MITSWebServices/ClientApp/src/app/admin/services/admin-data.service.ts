import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminDataService {

  pageTitle$: BehaviorSubject<String> = new BehaviorSubject("");
  removeActiveFromSpeakerList$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  removeActiveFromEventList$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  loggedIn$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  pageTitle(pageTitle: string): void {
    this.pageTitle$.next(pageTitle);
  }

  removeActiveFromSpeakerList(value: boolean): void {
    this.removeActiveFromSpeakerList$.next(value);
  }

  removeActiveFromEventList(value: boolean): void {
    this.removeActiveFromEventList$.next(value);
  }

  loggedIn(value: boolean): void {
    this.loggedIn$.next(value);
  }
}
