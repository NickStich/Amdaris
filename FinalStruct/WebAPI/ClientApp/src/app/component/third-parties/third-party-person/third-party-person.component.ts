import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { MatSort, Sort } from '@angular/material/sort';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { ThirdPersonType } from 'src/app/model/thirdPartyPerson/ThirdPersonType';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-third-party-person',
  templateUrl: './third-party-person.component.html',
  styleUrls: ['./third-party-person.component.css']
})
export class ThirdPartyPersonComponent implements OnInit {

  dataSource = new MatTableDataSource<ThirdPartyPerson>();
  displayedColumns = ['id', 'name', 'taxId', 'type', 'action'];
  tpps: ThirdPartyPerson[] = [];

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator , {static: true}) paginator: MatPaginator;

  constructor(private tppService: ThirdPartyPersonService) {

  }

  ngOnInit(): void {
    this.tppService.findAll().subscribe(data => {
      this.tpps = data;
      this.dataSource = new MatTableDataSource(this.tpps);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  deleteClick(tppId) {
    this.tppService.delete(tppId).subscribe();
    this.refreshPage();
  }

  refreshPage() {
    window.location.reload();
  }

  applyFilter(event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
