import { PlayerScore } from "./player-score.model";

export interface Game{
    id: number;
    currentRound: number;
    startedAt: Date;
    playerScores: PlayerScore[];
}