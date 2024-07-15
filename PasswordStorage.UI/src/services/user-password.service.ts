import {Injectable} from "@angular/core";
import {Constants} from "../constants";
import axios from "axios";
import {Observable, Subscriber} from "rxjs";
import {UserPassword} from "../types/user-password";

@Injectable({
  providedIn: 'any'
})
export class UserPasswordService
{
  public userPasswordsObserver = new Observable<UserPassword[]>(
  sub => this.userPasswordSubscriber=sub);
  private userPasswordSubscriber : Subscriber<UserPassword[]> = new  Subscriber<UserPassword[]>();

  private static lastQuery = "";

  public async search(query: string = "") : Promise<void> {
    UserPasswordService.lastQuery=query;
    const res = await axios.get(`${Constants.ApiBaseUrl}/passwords?query=${query}`);
    this.userPasswordSubscriber.next(res.data);
  }

  public async refresh() : Promise<void> {
    const res = await axios.get(`${Constants.ApiBaseUrl}/passwords?query=${UserPasswordService.lastQuery}`);
    this.userPasswordSubscriber.next(res.data);
  }

  public async addEmailPassword(email: string, password: string) : Promise<void> {
    return await axios.post(`${Constants.ApiBaseUrl}/passwords/email`, {email, password})
  }

  public async addWebsitePassword(url: string, password: string) : Promise<void> {
    return await axios.post(`${Constants.ApiBaseUrl}/passwords/website`, {url, password})
  }
}
