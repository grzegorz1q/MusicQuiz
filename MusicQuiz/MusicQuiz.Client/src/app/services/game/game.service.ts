import { Injectable } from '@angular/core';
import { environment } from '../../../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../../models/game.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private readonly apiUrl = `${environment.apiUrl}/games`;
  constructor(private http: HttpClient) {}

  createGame(playerIds: number[]): Observable<Game>{
    return this.http.post<Game>(`${this.apiUrl}`, { playerIds });
  }
  // getGameState(id: number): Observable<Game>{
  //   return this.http.get<Game>(`${this.apiUrl}/${id}/state`);
  // }
}
