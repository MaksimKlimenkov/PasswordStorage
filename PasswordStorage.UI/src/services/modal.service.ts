import {Injectable} from "@angular/core";
import {Constants} from "../constants";
import axios from "axios";
import {Observable, Subscriber} from "rxjs";
import {UserPassword} from "../types/user-password";

@Injectable({
  providedIn: 'any'
})
export class ModalService
{
  private static modalSubscribers : {[id: string] : Subscriber<boolean>} = {};

  public addSubscriber(modalName: string, subscriber: Subscriber<boolean>)
  {
    ModalService.modalSubscribers[modalName] = subscriber;
  }

  public getSubscriber(modalName: string) : Subscriber<boolean>
  {
    return ModalService.modalSubscribers[modalName];
  }
}
