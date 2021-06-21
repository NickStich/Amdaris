import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ThirdPartyPerson } from '../../model/thirdPartyPerson/third-party-person';

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

  public save(tpp: ThirdPartyPerson) {
    return this.http.post<ThirdPartyPerson>(this.tppUrl + '/Create', tpp);
  }

  public update(tppId: number, tpp: ThirdPartyPerson) {
    return this.http.put(this.tppUrl + '/Update/' + tppId, tpp);
  }

  public delete(tppId: number) {
    return this.http.delete(this.tppUrl + '/Delete/' + tppId);
  }

  public getById(tppId: number) {
    return this.http.get<ThirdPartyPerson>(this.tppUrl + '/GetById/' + tppId);
  }

  public getType(): Observable<string[]> {
    return this.http.get<string[]>(this.tppUrl + '/GetType');
  }

  public getByType(tppType: number): Observable<ThirdPartyPerson[]> {
    return this.http.get<ThirdPartyPerson[]>(this.tppUrl + '/GetByType/' + tppType);
  }
}
