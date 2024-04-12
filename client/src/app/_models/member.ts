import { Photo } from "./photo";

export interface Member {
    id:           number;
    username:     string;
    gender:       string;
    photoUrl:     string;
    age:          number;
    dateOfBirth:  Date;
    knownAs:      string;
    created:      Date;
    lastActive:   Date;
    introduction: string;
    lookingFor:   string;
    interests:    string;
    city:         string;
    country:      string;
    photos:       Photo[];
}