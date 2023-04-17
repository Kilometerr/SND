import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { outfitIds } from '../models/outfitIds.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  constructor(private http: HttpClient) { }

  getAllOutfitIDs(): Observable<outfitIds[]> {
    return this.http.get<outfitIds[]>('http://localhost:5103/api/Item');
  }
}
