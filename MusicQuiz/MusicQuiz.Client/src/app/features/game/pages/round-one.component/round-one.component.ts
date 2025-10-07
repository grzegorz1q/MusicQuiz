import { Component, Input, OnInit } from '@angular/core';
import { User } from '../../../../models/user.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-round-one.component',
  imports: [],
  templateUrl: './round-one.component.html',
  styleUrl: './round-one.component.scss',
})
export class RoundOneComponent implements OnInit {
  gameId!: number;
  players: User[] = [];

  constructor(private route: ActivatedRoute){}

  ngOnInit(){
    this.gameId = Number(this.route.snapshot.paramMap.get('id'));
    console.log('Loaded game ID: ', this.gameId);
  }
  
}
