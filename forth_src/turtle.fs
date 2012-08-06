

s" gfx" load
s" sin" load

var tx var ty # 10.6 fixedpoint
var ta : tp 0 ;

: s2/ ( signed 2/ )
2/ dup 4000 and if 8000 or then ;
: ls 2* 2* 2* 2* 2* 2* ;
: rs s2/ s2/ s2/ s2/ s2/ s2/ ;
: pendown 1 to tp tx @ rs ty @ rs plot ;
: penup 0 to tp ;

: init hires 7 clrcol 
a0 ls tx ! 64 ls ty ! pendown 
10e ta ! ( north ) ;

: right ( a -- )
ta @ +
dup 8000 and if 168 + then
168 mod ta ! ;
: left ( a -- )
negate right ;
: forward ( px -- )
ls dup ta @ *cos tx +!
ta @ *sin ty +!
tp if tx @ rs ty @ rs line then ;
: back ( px -- )
80 right forward 80 right ;

(
# --- demo

: polyspiral
." init distance? " interpret 
." angle? " interpret
." distance step? " interpret 
init
64 >r begin
2 pick forward
over left
rot over + -rot
r> 1- dup >r 0= until r> 2drop 2drop
5 d020 c! key drop lores 0 d020 c! ;

: inward
." distance? " interpret 
." init angle? " interpret
." angle step? " interpret 
init
begin 2 pick forward
over right
swap over + 168 mod swap again ;
)
