import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../../../../models/game.model';
import { GameService } from '../../../../services/game/game.service';

@Component({
  selector: 'app-round-one.component',
  imports: [],
  templateUrl: './round-one.component.html',
  styleUrl: './round-one.component.scss',
})
export class RoundOneComponent implements OnInit {
  //gameId!: number;
  game!: Game;

  constructor(private route: ActivatedRoute, private gameService: GameService){}

  ngOnInit(){
    const navigate = history.state;
    this.game = navigate.response;
    console.log('Loaded game', this.game);
  }
  // getGameState(id: number){
  //   this.gameService.getGameState(id).subscribe({
  //     next: (response) => {
  //       this.game = response;
  //       console.log(response);
  //     },
  //     error: (error) => {
  //       console.error(error);
  //     }
  //   })
  // }
  
}
