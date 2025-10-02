import { Routes } from '@angular/router';
import { HomePageComponent } from './features/home/pages/home-page.component/home-page.component';
import { SelectPlayersComponent } from './features/game/pages/select-players.component/select-players.component';

export const routes: Routes = [
    {
        path:'',
        component: HomePageComponent
    },
    {
        path:'select-players',
        component: SelectPlayersComponent
    }
];
