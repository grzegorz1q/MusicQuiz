import { Injectable } from '@angular/core';
import { environment } from '../../../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private readonly apiUrl = `${environment.apiUrl}/games`;
  constructor(private http: HttpClient) {}

  createGame(playerIds: number[]): Observable<number[]>{
    return this.http.post<number[]>(`${this.apiUrl}`, { playerIds });
  }
}
