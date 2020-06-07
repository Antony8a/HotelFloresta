import { Injectable, Inject } from '@angular/core';
import { Users } from '../models/users';
import { BehaviorSubject, Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<Users>;
  public currentUser: Observable<Users>;
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService){
    this.currentUserSubject = new BehaviorSubject<Users>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
    this.baseUrl = baseUrl;
  }

  public get currentUserValue(): Users {
    return this.currentUserSubject.value;
  }

  login(username:string, password:string) {
    return this.http.post<any>(`${this.baseUrl}api/login`, { username, password })
      .pipe(map(user => {
        if (user && user.token) {
          // store user and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }
        return user;
      }));

  }

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

}
