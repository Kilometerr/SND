import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/models/items.model';
import { ItemsService } from '../../../services/items.service';
import { outfitIds } from 'src/app/models/outfitIds.model';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.css']
})
export class ItemsListComponent implements OnInit {

  itemsList: outfitIds[] = [];
  constructor(private itemservice: ItemsService) { }

  ngOnInit(): void {
    this.itemservice.getAllOutfitIDs()
    .subscribe({
      next: (itemsList) =>{
        this.itemsList = itemsList;
      },
      error: (response) =>{
        console.log(response);
      }
    });
  }

}
