import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ToDo } from '../models/toDo';
import { Router } from '@angular/router';
import { UpdateItem } from '../models/updateItem';

@Component({
  selector: 'app-to-do',
  templateUrl: './to-do.component.html',
  styleUrls: ['./to-do.component.css']
})
export class ToDoComponent {
  @Input() items: ToDo[] = [];
  @Input() listTitle: string = '';

  @Output('deleteItem') deleteItem: EventEmitter<number> = new EventEmitter();
  @Output('editItem') editItem: EventEmitter<UpdateItem> = new EventEmitter();
  @Output('completeItem') completeItem: EventEmitter<UpdateItem> = new EventEmitter();

  isEditMode: boolean = false;

  constructor(private router: Router) { }

  onDelete = (id: number) => this.deleteItem.emit(id);

  onEdit = (id: number) => this.router.navigate([`/edit/${id}`]);

  onComplete = (item: ToDo): void => {
    const editedItem = new UpdateItem(item.id, item.description, true);
    this.completeItem.emit(editedItem);
  }
}
