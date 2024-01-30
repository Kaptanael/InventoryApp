import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

import { MenuService } from '../../_services/menu.service';

@Component({
  selector: 'app-menu',  
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {

  public menus: any[] = [];
  public selectedMenuId: string | undefined;
  public selectedMenu: object | undefined;

  constructor(private menuService: MenuService,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.menuService.getAll().subscribe({
      next: (res) => {
        console.log(res);
        this.menus = res.body;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEdit(menu: any) {
    this.router.navigate(['./add-edit-menu', menu.id], { relativeTo: this.route });
  }

  onDelete(menu: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete this <b>${menu.name}</b>`,
      accept: () => {
        this.menuService.delete(menu.id)
          .subscribe({
            next: (res) => {
              if (res.status === 200) {
                this.getAll();
                this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `Menu ${menu.name} has been deleted.`, detail: '' });
              }
            },
            error: (err) => {
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Failed to delete menu.', detail: '' });
            }
          });
      }
    });
  }
}

