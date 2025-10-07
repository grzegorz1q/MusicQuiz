import { Component, OnInit } from '@angular/core';
import { Scoreboard } from '../../../../models/scoreboard.model';
import { ScoreboardService } from '../../../../services/scoreboard/scoreboard.service';

@Component({
  selector: 'app-scoreboard.component',
  imports: [],
  templateUrl: './scoreboard.component.html',
  styleUrl: './scoreboard.component.scss'
})
export class ScoreboardComponent implements OnInit {
  scoreboard: Scoreboard[] = [];

  constructor(private scoreboardService: ScoreboardService){}

  ngOnInit(){
    this.getScoreboard();
  }

  getScoreboard(){
    this.scoreboardService.getScoreboard().subscribe({
      next: (scoreboard) =>{
        this.scoreboard = scoreboard;
      },
      error: (error) =>{
        console.error(error);
      }
    });
  }
}
