import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Position } from 'src/app/model/position/position';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  private positionUrl: string;

  constructor(private http: HttpClient) {
    this.positionUrl = 'https://localhost:44380/pos';
  }

  public findAll(): Observable<Position[]> {
    return this.http.get<Position[]>(this.positionUrl + '/GetAll');
  }

  public save(position: Position) {
    return this.http.post<Position>(this.positionUrl + '/Create', position);
  }

  public update(positionId: number, position: Position) {
    return this.http.put(this.positionUrl + '/Update/' + positionId, position);
  }

  public delete(positionId: number) {
    return this.http.delete(this.positionUrl + '/Delete/' + positionId);
  }

  public getById(positionId: number) {
    return this.http.get<Position>(this.positionUrl + '/GetById/' + positionId);
  }
}
