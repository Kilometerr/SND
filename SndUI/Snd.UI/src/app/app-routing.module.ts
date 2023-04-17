import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemsListComponent } from './components/Items/items-list/items-list.component';

const routes: Routes = [
  {
    path: '',
    component: ItemsListComponent
  },
  {
    path: 'items',
    component: ItemsListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
