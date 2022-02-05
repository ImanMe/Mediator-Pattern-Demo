import { ToDo } from './../models/toDo';
import { ToDoService } from './../to-do.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UpdateItem } from '../models/updateItem';

@Component({
  selector: 'app-edit-item',
  templateUrl: './edit-item.component.html',
  styleUrls: ['./edit-item.component.css']
})
export class EditItemComponent implements OnInit {

  constructor(private toDoService: ToDoService, private route: ActivatedRoute, private router: Router) { }
  item: ToDo = new ToDo();
  updatedItem: UpdateItem = new UpdateItem();
  isDataLoaded = false;

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.getItem(params['id']);
    });
  }

  getItem = (id: number) => {
    this.toDoService.getItem(id).subscribe(result => {
      this.item = result,
        this.isDataLoaded = true;
    }, error => {
      console.log(error);
    });
  }

  onSave = () => {
    let updatedItem = new UpdateItem(this.item.id, this.item.description, false);
    this.toDoService.updateItem(updatedItem).subscribe(result => {
      this.router.navigate(['/']);
    }, error => {
      console.log(error);
    })
  }

  onCancel = () => this.router.navigate(['/']);
}
