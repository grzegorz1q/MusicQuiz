import { Component, OnInit } from '@angular/core';
import { User } from '../../../../models/player.model';
import { AccountService } from '../../../../services/account/account.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { GameService } from '../../../../services/game/game.service';

@Component({
  selector: 'app-select-players.component',
  imports: [ReactiveFormsModule],
  templateUrl: './select-players.component.html',
  styleUrl: './select-players.component.scss'
})
export class SelectPlayersComponent implements OnInit {
  form!: FormGroup;
  selectedPlayers: User[] = [];
  availablePlayers: User[] = [];

  constructor(private accountService: AccountService, private gameService: GameService, private fb: FormBuilder) {}
  
  ngOnInit(){
    this.getAllUsers();
    this.form = this.fb.group({
      playerSelect: null
    });
  }

  addPlayer(player: User){
    if(this.selectedPlayers.length >= 3){
      alert('You can add only 3 players');
      return;
    }
    if(this.selectedPlayers.find(p => p.id === player.id)){
      alert('Player already added');
      return;
    }
    this.selectedPlayers.push(player);
    this.form.get('playerSelect')?.setValue(null);
  }

  removePlayer(player: User){
    this.selectedPlayers = this.selectedPlayers.filter(p => p.id !== player.id);
  }

  submit(){
    if(this.selectedPlayers.length !== 3){
      alert('You have to add 3 players');
      return;
    }
    console.log('Selected players:', this.selectedPlayers);
    this.createGame(this.selectedPlayers.map(p => p.id));
  }

  getAllUsers(){
    this.accountService.getAllUsers().subscribe({
      next: (users) => {
        this.availablePlayers = users;
      },
      error: (error) =>{
        console.error(error);
      }
    });
  }

  createGame(playerIds: number[]){
    this.gameService.createGame(playerIds).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) =>{
        console.error(error);
      }
    });
  }
}
