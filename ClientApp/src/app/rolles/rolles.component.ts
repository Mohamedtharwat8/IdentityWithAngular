import { Component, OnInit } from '@angular/core';
import { RollesService } from './rolles.service';

@Component({
  selector: 'app-rolles',
  templateUrl: './rolles.component.html',
  styleUrls: ['./rolles.component.css']
})
export class RollesComponent implements OnInit{
message: string | undefined;

constructor(private rollesService: RollesService){

}
  ngOnInit(): void {
this.rollesService.getRolles().subscribe({
  next: (respose: any) => this.message = respose.value.message,
  error: (error: any) => console.log(error)
})
}

}
