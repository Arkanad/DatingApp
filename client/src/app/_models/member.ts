import { Photo } from "./photo";


export interface Member {
    Username:     string;
    Gender:       string;
    DateOfBirth:  Date;
    KnownAs:      string;
    Created:      Date;
    LastActive:   Date;
    Introduction: string;
    LookingFor:   string;
    Interests:    string;
    City:         string;
    Country:      string;
    Photos:       Photo[];
}

