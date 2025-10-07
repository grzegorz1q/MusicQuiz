import { Injectable } from '@angular/core';
import { environment } from '../../../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Scoreboard } from '../../models/scoreboard.model';

@Injectable({
  providedIn: 'root'
})
export class ScoreboardService {
  private readonly apiUrl = `${environment.apiUrl}/scoreboard`;
  constructor(private http: HttpClient ) {}
  
  getScoreboard(): Observable<Scoreboard[]>{
    return this.http.get<Scoreboard[]>(`${this.apiUrl}`);
  }
}
