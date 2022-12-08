create table menumakanan(id smallserial primary key,
						nama_makanan varchar(50) not null,
						harga_makanan int not null)

create table menuminuman(id smallserial primary key,
						nama_minuman varchar(50) not null,
						harga_minuman int not null)
						
create table datapesananmakanan(id smallserial primary key,
						nama_pelanggan varchar(50) not null,
						pesanan varchar(50) not null,
						jumlah int not null,
						total_harga int not null,
						status varchar(10) not null)