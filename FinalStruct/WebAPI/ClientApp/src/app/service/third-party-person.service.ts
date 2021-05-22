import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ThirdPartyPerson } from '../model/third-party-person';

@Injectable({
  providedIn: 'root'
})
export class ThirdPartyPersonService {

  private tppUrl: string;

  constructor(private http: HttpClient) {
    this.tppUrl = 'https://localhost:44380/tpp';
  }

  public findAll(): Observable<ThirdPartyPerson[]> {
    return this.http.get<ThirdPartyPerson[]>(this.tppUrl + '/GetAll');
  }

  public save(operation: ThirdPartyPerson) {
    return this.http.post<ThirdPartyPerson>(this.tppUrl + '/Create', operation);
  }
}
