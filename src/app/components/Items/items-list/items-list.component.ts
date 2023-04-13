import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/models/items.model';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.css']
})
export class ItemsListComponent implements OnInit {

  itemsList: Items[] = [
    {
      id: 1,
      name: 'testName1',
      soldToday: 2,
      soldWeek: 3
    },
    {
      id: 2,
      name: 'testName2',
      soldToday: 3,
      soldWeek: 4
    }
  ];
  constructor() { }

  ngOnInit(): void {
    this.itemsList.push()
  }

}
