import { Routes } from '@angular/router';
import { HomePageComponent } from './features/home/pages/home-page.component/home-page.component';
import { SelectPlayersComponent } from './features/game/pages/select-players.component/select-players.component';
import { ScoreboardComponent } from './features/scoreboard/pages/scoreboard.component/scoreboard.component';
import { RoundOneComponent } from './features/game/pages/round-one.component/round-one.component';

export const routes: Routes = [
    {
        path:'',
        component: HomePageComponent
    },
    {
        path:'select-players',
        component: SelectPlayersComponent
    },
    {
        path:'scoreboard',
        component: ScoreboardComponent
    },
    {
        path: 'round-one/:id',
        component: RoundOneComponent
    }
];
